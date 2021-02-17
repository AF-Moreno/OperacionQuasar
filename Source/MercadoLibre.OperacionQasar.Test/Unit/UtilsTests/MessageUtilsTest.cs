namespace MercadoLibre.OperacionQasar.Test.Unit.Utils
{
    using MercadoLibre.OperacionQuasar.Core.Utils;
    using System;
    using System.Collections.Generic;
    using Xunit;

    public class MessageUtilsTest
    {
        #region [SETUP]
        public static IEnumerable<object[]> GetMessage_ListMessages_Success_MemberData => new List<object[]>()
        {
            new object[]
            {
                new List<string[]>
                {
                    new string[] { "", "", "", "mensaje", "" },
                    new string[] { "", "es", "", "", "secreto" },
                    new string[] { "este", "", "un", "", "" }
                }
            },
            new object[]
            {
                new List<string[]>
                {
                    new string[] { "este", "", "un", "", "" },
                    new string[] { "", "", "", "mensaje", "" },
                    new string[] { "", "es", "", "", "secreto" },
                }
            },
            new object[]
            {
                new List<string[]>
                {
                    new string[] { "este", "es", "un", "mensaje", "" },
                    new string[] { "este", "es", "un", "", "" },
                    new string[] { "este", "es", "un", "", "secreto" }
                }
            },
        };

        public static IEnumerable<object[]> GetMessage_ListMessages_Exception_MemberData => new List<object[]>()
        {
            new object[]
            {
                new List<string[]>
                {
                    new string[] { "", "", "mensaje", "" },
                    new string[] { "", "es", "", "", "secreto" },
                    new string[] { "este", "", "un", "", "" }
                }
            },
            new object[]
            {
                new List<string[]>
                {
                    new string[] { "este", "", "un", "", "" },
                    new string[] { "" },
                    new string[] { "", "es", "", "", "secreto" },
                }
            },
            new object[]
            {
                new List<string[]>
                {
                    new string[] { "este", "", "", "mensaje", "" },
                    new string[] { "este", "", "un", "", "" },
                    new string[] { "44324", "es", "", "", "secreto" }
                }
            },
        };
        #endregion

        [Theory]
        [MemberData(nameof(GetMessage_ListMessages_Success_MemberData))]
        public void GetMessage_ListMessages_Success(IEnumerable<string[]> messages)
        {
            // Arrange
            string expectedResult = "este es un mensaje secreto";

            // Act
            string result = MessageUtils.GetMessage(messages);

            // Assert
            Assert.False(string.IsNullOrWhiteSpace(result));
            Assert.True(string.Equals(result, expectedResult, System.StringComparison.CurrentCultureIgnoreCase));
        }

        [Theory]
        [MemberData(nameof(GetMessage_ListMessages_Exception_MemberData))]
        public void GetMessage_ListMessages_Exception(IEnumerable<string[]> messages)
        {
            // Act & Assert
            Assert.ThrowsAny<Exception>(() => MessageUtils.GetMessage(messages));
        }
    }
}
