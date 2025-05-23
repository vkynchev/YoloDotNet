﻿namespace YoloDotNet.Tests.OBBDetectionTests
{
    public class Yolov11OBBDetectionTests
    {
        [Fact]
        public void RunObbDetection_Yolov11_GetExpectedNumberOfObjects_AssertTrue()
        {
            // Arrange
            var model = SharedConfig.GetTestModelV11(ModelType.ObbDetection);
            var testImage = SharedConfig.GetTestImage(ImageType.Island);

            var yolo = new Yolo(new YoloOptions
            {
                OnnxModel = model,
                ModelType = ModelType.ObbDetection,
                HwAccelerator = HwAcceleratorType.None
            });

            var image = SKImage.FromEncodedData(testImage);

            // Act
            var results = yolo.RunObbDetection(image, 0.25, 0.45);

            // Assert
            Assert.Equal(5, results.Count);
        }
    }
}
