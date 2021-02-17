namespace MercadoLibre.OperacionQasar.Test.Unit.Utils
{
    using MercadoLibre.OperacionQuasar.Core.Models;
    using MercadoLibre.OperacionQuasar.Core.Utils;
    using System;
    using System.Collections.Generic;
    using Xunit;

    public class TrilaterationUtilsTest
    {
        #region [SETUP]
        public static IEnumerable<object[]> GetLocation_TrilaterationPoints_Success_MemberData => new List<object[]>()
        {
            new object[]
            {
                new TrilaterationPointModel[]
                {
                    new  TrilaterationPointModel() { X = -500, Y = -200, Distance = 100.0F },
                    new  TrilaterationPointModel() { X = 100, Y = -100, Distance = 115.5F },
                    new  TrilaterationPointModel() { X = 500, Y = 100, Distance = 142.7F },
                },
                new PositionModel() { X = -487.28592F, Y = 1557.0143F }
            }
        };

        public static IEnumerable<object[]> GetLocation_TrilaterationPoints_Exception_MemberData => new List<object[]>()
        {
            new object[]
            {
                new TrilaterationPointModel[]
                {
                    new  TrilaterationPointModel() { X = -500, Y = -200, Distance = 100.0F },
                    new  TrilaterationPointModel() { X = 100, Y = -100, Distance = 115.5F },
                }
            },
           new object[]
           {
                new TrilaterationPointModel[]
                {
                    new  TrilaterationPointModel() { X = -500, Y = -200, Distance = 100.0F },
                    new  TrilaterationPointModel() { X = 100, Y = -100, Distance = 115.5F },
                    new  TrilaterationPointModel() { X = -500, Y = -200, Distance = 100.0F },
                    new  TrilaterationPointModel() { X = 100, Y = -100, Distance = 115.5F },
                }
           }
        };
        #endregion

        [Theory]
        [MemberData(nameof(GetLocation_TrilaterationPoints_Success_MemberData))]
        public void GetLocation_TrilaterationPoints_Success(TrilaterationPointModel[] trilaterationPoints, PositionModel expectedResult)
        {
            // Act
            var result = TrilaterationUtils.GetLocation(trilaterationPoints);

            // Assert
            Assert.Equal(result.X, expectedResult.X);
            Assert.Equal(result.Y, expectedResult.Y);
        }

        [Theory]
        [MemberData(nameof(GetLocation_TrilaterationPoints_Exception_MemberData))]
        public void GetLocation_TrilaterationPoints_Exception(TrilaterationPointModel[] trilaterationPoints)
        {
            // Act & Assert
            Assert.ThrowsAny<Exception>(() => TrilaterationUtils.GetLocation(trilaterationPoints));
        }
    }
}
