namespace MercadoLibre.OperacionQuasar.Core.Utils
{
    using MercadoLibre.OperacionQuasar.Core.Models;
    using System;
    using System.Linq;

    public class TrilaterationUtils
    {
        public static PositionModel GetLocation(TrilaterationPointModel[] trilaterationPoints)
        {
            if (trilaterationPoints.Count() == 3)
            {
                var x1 = trilaterationPoints[0].X;
                var y1 = trilaterationPoints[0].Y;
                var r1 = trilaterationPoints[0].Distance;

                var x2 = trilaterationPoints[1].X;
                var y2 = trilaterationPoints[1].Y;
                var r2 = trilaterationPoints[1].Distance;

                var x3 = trilaterationPoints[2].X;
                var y3 = trilaterationPoints[2].Y;
                var r3 = trilaterationPoints[2].Distance;

                (var A, var B, var C) = GetBasicEcuations(x1, x2, y1, y2, r1, r2);
                (var D, var E, var F) = GetBasicEcuations(x2, x3, y2, y3, r2, r3);

                var x = ((C * E) - (F * B)) / ((E * A) - (B * D));
                var y = ((C * D) - (A * F)) / ((B * D) - (A * E));

                return new PositionModel() { X = (float)x, Y = (float)y };
            }

            throw new InvalidOperationException("The distances of the satellites are indecipherable.");
        }

        private static (double, double, double) GetBasicEcuations(double x1, double x2, double y1, double y2, double r1, double r2)
        {
            var A = 2 * x2 - 2 * x1;
            var B = 2 * y2 - 2 * y1;
            var C = Math.Pow(r1, 2) - Math.Pow(r2, 2) - Math.Pow(x1, 2) + Math.Pow(x2, 2) - Math.Pow(y1, 2) + Math.Pow(y2, 2);

            return (A, B, C);
        }
    }
}
