const csv = require("csv-parser");
const fs = require("fs");
const brain = require("brain.js");

const trainingData = [];

fs.createReadStream(
  "/Users/mitevpi/Documents/GitHub/daylighting-design-space/data/training-data.csv"
)
  .pipe(csv())
  .on("data", row => {
    const formattedRow = {
      input: {
        ceilingHeight: +row["in:Ceiling Height"],
        ceilingReflectance: +row["in:Ceiling Reflectance"],
        depth: +row["in:Depth"],
        floorReflectance: +row["in:Floor Reflectance"],
        location: row["in:location"],
        obstructAngle: +row["in:ObstructAngle"],
        orientation: +row["in:Orientation"],
        shadeTriggerDistance: +row["in:Shade Trigger Distance (1000 direct)"],
        spacingBetweenWindows: +row["in:Spacing Between Windows"],
        wallReflectance: +row["in:Wall Reflectance"],
        wallThickness: +row["in:Wall Thickness"],
        width: +row["in:Width"],
        windowBottomSill: +row["in:Window Bottom Sill"],
        windowTopSill: +row["in:Window Top Sill"],
        windowWidth: +row["in:Window Width"],
        wwr: +row["in:WWR"]
      },
      output: { D300: +row["out:D300"] }
    };

    trainingData.push(formattedRow);
    console.log(formattedRow);
  })
  .on("end", () => {
    console.log("CSV file successfully processed");

    const config = {
      // binaryThresh: 0.5, // if binary classification, where to draw the line between 0 and 1
      hiddenLayers: [3, 3], // array of ints for the sizes of the hidden layers in the network
      activation: "relu", // supported activation types: ['sigmoid', 'relu', 'leaky-relu', 'tanh'],
      leakyReluAlpha: 0.01, // supported for activation type 'leaky-relu'
      iterations: 10000, // how many times to train over the data
      learningRate: 0.5 // how much we are adjusting the weights of our network with respect the loss gradient
    };
    const net = new brain.NeuralNetwork(config);

    // train and log for debug
    const stats = net.train(trainingData, {
      log: error => console.log(error)
    });
  });
