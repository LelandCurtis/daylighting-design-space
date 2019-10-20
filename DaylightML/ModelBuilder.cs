using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;
using Microsoft.ML.Trainers.LightGbm;

namespace DaylightML
{
    public static class ModelBuilder
    {
        private static MLContext mlContext = new MLContext(seed: 1);
        public static string TRAINING_DATA_FILEPATH = AssemblyDirectory() + @"2019-0925 Daylighting Design Space - Trainer.csv";
        private static string TEST_DATA_FILEPATH = AssemblyDirectory() + @"MLModel.zip";



        public static void CreateModel()
        {

            // Load training data
            IDataView baseTrainingDataView = mlContext.Data.LoadFromTextFile<Model.ModelInput>(
                                                path: TRAINING_DATA_FILEPATH,
                                                hasHeader: true,
                                                separatorChar: ',',
                                                allowQuoting: true,
                                                allowSparse: false);

            //load testing data
            IDataView testDataView = mlContext.Data.LoadFromTextFile<Model.ModelInput>(
                                            path: TEST_DATA_FILEPATH,
                                            hasHeader: true,
                                            separatorChar: ',',
                                            allowQuoting: true,
                                            allowSparse: false);

            // Build training pipeline
            IEstimator<ITransformer> trainingPipeline = BuildTrainingPipeline(mlContext);
            
            // Evaluate quality of Model
            //Evaluate(mlContext, trainingDataView, trainingPipeline);
            
            // Train Model
            ITransformer mlModel = TrainModel(mlContext, baseTrainingDataView, trainingPipeline);
            
            // Save model
            //SaveModel(mlContext, mlModel, MODEL_FILEPATH, trainingDataView.Schema);
            
        }

        public static IEstimator<ITransformer> BuildTrainingPipeline(MLContext mlContext)
        {
            // Data process configuration with pipeline data transformations 
            var dataProcessPipeline = mlContext.Transforms.Conversion.MapValueToKey("out:sDA300", "out:sDA300")
                                        .Append(mlContext.Transforms.Categorical.OneHotEncoding(new[] { new InputOutputColumnPair("in:location", "in:location") }));
                                        //.Append(mlContext.Transforms.Concatenate("Features", new[] { "in:location", "in:Orientation", "in:ObstructAngle", "in:Width", "in:Depth", "in:Ceiling Height", "in:Wall Thickness", "in:Window Width", "in:Window Bottom Sill", "in:Window Top Sill", "in:Spacing Between Windows", "in:WWR", "in:Ceiling Reflectance", "in:Wall Reflectance", "in:Floor Reflectance", "in:Shade Trigger Distance (1000 direct)" }));

            // Set the training algorithm 
            var trainer = mlContext.MulticlassClassification.Trainers.LightGbm(labelColumnName: "out:sDA300", featureColumnName: "Features")
                                        .Append(mlContext.Transforms.Conversion.MapKeyToValue("PredictedLabel", "PredictedLabel"));

            //Add trainer to the data pipeline
            var trainingPipeline = dataProcessPipeline.Append(trainer);

            return trainingPipeline;
        }

        public static ITransformer TrainModel(MLContext mlContext, IDataView trainingDataView, IEstimator<ITransformer> trainingPipeline)
        {
            ITransformer model = trainingPipeline.Fit(trainingDataView);
            return model;
        }

        /*
        private static void Evaluate(MLContext mlContext, IDataView trainingDataView, IEstimator<ITransformer> trainingPipeline)
        {
            IDataView predictions = trainedModel.Transform(testDataView);
            var metrics = mlContext.Regression.Evaluate(predictions, labelColumnName: "Label", scoreColumnName: "Score");

            Common.ConsoleHelper.PrintRegressionMetrics(trainer.ToString(), metrics);
        }
        */

        /*
        private static void SaveModel(MLContext mlContext, ITransformer mlModel, string modelRelativePath, DataViewSchema modelInputSchema)
        {
            // Save/persist the trained model to a .ZIP file
            mlContext.Model.Save(mlModel, modelInputSchema, GetAbsolutePath(modelRelativePath));
            Console.WriteLine("The model is saved to {0}", GetAbsolutePath(modelRelativePath));
        }
        */

        /*
        public static string GetAbsolutePath(string relativePath)
        {
            FileInfo _dataRoot = new FileInfo(typeof(Program).Assembly.Location);
            string assemblyFolderPath = _dataRoot.Directory.FullName;

            string fullPath = Path.Combine(assemblyFolderPath, relativePath);

            return fullPath;
        }
        */

        public static string AssemblyDirectory()
        {
            string codeBase = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path);
           
        }


        public static Model.ModelOutput Consume(MLContext mlContext, ITransformer mlModel, Model.ModelInput input) {

            // Load model & create prediction engine
            var predEngine = mlContext.Model.CreatePredictionEngine<Model.ModelInput, Model.ModelOutput>(mlModel);

            // Use model to make prediction on input data
            Model.ModelOutput result = predEngine.Predict(input);
            return result;
        }

    }
}
