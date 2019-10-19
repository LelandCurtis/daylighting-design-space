using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Transforms;
using static Microsoft.ML.Transforms.NormalizingEstimator;
using Model.Models;

namespace Model
{
    class Program
    {
        static readonly string _trainDataPath =
            "/Users/mitevpi/Documents/GitHub/daylighting-design-space/Model/Data/training-data.csv";

        static readonly string _testDataPath =
            "/Users/mitevpi/Documents/GitHub/daylighting-design-space/Model/Data/test-data.csv";
        static readonly string _modelPath = Path.Combine(Environment.CurrentDirectory, "Data", "Model.zip");

        static void Main(string[] args)
        {
            MLContext mlContext = new MLContext(0);
            ITransformer model = Train(mlContext, _trainDataPath, _testDataPath);
            
            TestSinglePrediction(mlContext, model);

            Console.WriteLine("Done!");
            Console.Read();
        }

        public static ITransformer Train(MLContext mlContext, string dataPath, string testDataPath)
        {
            IDataView dataView =
                mlContext.Data.LoadFromTextFile<Simulation>(dataPath, hasHeader: true, separatorChar: ',');

            IDataView dataViewTest =
                mlContext.Data.LoadFromTextFile<Simulation>(testDataPath, hasHeader: true, separatorChar: ',');

            EstimatorChain<ColumnConcatenatingTransformer> pipeline = mlContext.Transforms
                .CopyColumns("Label", nameof(Simulation.DA300))
                .Append(mlContext.Transforms.Categorical.OneHotEncoding("LocationEncoded", nameof(Simulation.Location)))
                .Append(mlContext.Transforms.NormalizeMeanVariance(nameof(Simulation.Orientation)))
                .Append(mlContext.Transforms.NormalizeMeanVariance(nameof(Simulation.ObstructAngle)))
                .Append(mlContext.Transforms.NormalizeMeanVariance(nameof(Simulation.Depth)))
                .Append(mlContext.Transforms.NormalizeMeanVariance(nameof(Simulation.Width)))
                .Append(mlContext.Transforms.NormalizeMeanVariance(nameof(Simulation.CeilingHeight)))
                .Append(mlContext.Transforms.NormalizeMeanVariance(nameof(Simulation.WallThickness)))
                .Append(mlContext.Transforms.NormalizeMeanVariance(nameof(Simulation.WindowWidth)))
                .Append(mlContext.Transforms.NormalizeMeanVariance(nameof(Simulation.WindowBottomSill)))
                .Append(mlContext.Transforms.NormalizeMeanVariance(nameof(Simulation.WindowTopSill)))
                .Append(mlContext.Transforms.NormalizeMeanVariance(nameof(Simulation.SpacingBetweenWindow)))
                .Append(mlContext.Transforms.NormalizeMeanVariance(nameof(Simulation.WWR)))
                .Append(mlContext.Transforms.NormalizeMeanVariance(nameof(Simulation.CeilingReflectance)))
                .Append(mlContext.Transforms.NormalizeMeanVariance(nameof(Simulation.WallReflectance)))
                .Append(mlContext.Transforms.NormalizeMeanVariance(nameof(Simulation.FloorReflectance)))
                .Append(mlContext.Transforms.NormalizeMeanVariance(nameof(Simulation.ShadeTriggerDistance)))
                .Append(mlContext.Transforms.Concatenate("Features", "LocationEncoded", nameof(Simulation.Orientation),
                    nameof(Simulation.Depth), nameof(Simulation.Width), nameof(Simulation.CeilingHeight),
                    nameof(Simulation.WallThickness), nameof(Simulation.WindowWidth),
                    nameof(Simulation.WindowBottomSill),
                    nameof(Simulation.WindowTopSill),
                    nameof(Simulation.SpacingBetweenWindow), nameof(Simulation.WWR),
                    nameof(Simulation.CeilingReflectance), nameof(Simulation.WallReflectance),
                    nameof(Simulation.FloorReflectance),
                    nameof(Simulation.ShadeTriggerDistance)));

            var trainer = mlContext.Regression.Trainers.Sdca("Label", "Features");
            var trainingPipeline = pipeline.Append(trainer);

            Console.WriteLine("=============== Training the model ===============");
            var model = pipeline.Fit(dataView);

            Console.WriteLine("===== Evaluating Model's accuracy with Test data =====");
            IDataView predictions = model.Transform(dataViewTest);
            var metrics =
                mlContext.Regression.Evaluate(predictions, labelColumnName: "Label", scoreColumnName: "DA300");
            Console.WriteLine($"*       RSquared Score:      {metrics.RSquared:0.##}");
            Console.WriteLine($"*       Root Mean Squared Error:      {metrics.RootMeanSquaredError:#.##}");
            Console.WriteLine($"*       Mean Squared Error:      {metrics.MeanSquaredError:#.##}");

            return model;
        }
        
        private static void TestSinglePrediction(MLContext mlContext, ITransformer model)
        {
            var predictionFunction = mlContext.Model.CreatePredictionEngine<Simulation, SimulationResult>(model);
            
            Simulation sample = new Simulation()
            {
                Location = "PH",
                Orientation = 0,
                ObstructAngle = 40,
                Width = 40,
                Depth = 40,
                CeilingHeight = 9,
                WallThickness = (float) 0.5,
                WindowWidth = 4,
                WindowBottomSill = (float) 2.5,
                WindowTopSill = (float) 8.7,
                SpacingBetweenWindow = 2,
                WWR = (float) 0.41,
                CeilingReflectance = 80,
                WallReflectance = 60,
                FloorReflectance = 20,
                ShadeTriggerDistance = 1,
//                DA300 = 0
            };
            
            SimulationResult prediction = predictionFunction.Predict(sample);
            Console.WriteLine($"**********************************************************************");
            Console.WriteLine($"Predicted SDA300: {prediction.DA300}, actual sda: 0.33");
            Console.WriteLine($"**********************************************************************");

        }
    }
}