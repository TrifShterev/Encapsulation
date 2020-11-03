using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private const string INVALID_SIDE_ECEPTION_MSG = "{0} cannot be zero or negative.";
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double Length
        {
            get { return length; }
            private set
            {
                ValidateSide(value, nameof(Length));
                length = value;
            }
        }

        public double Width
        {
            get { return width; }
            private set
            {
                ValidateSide(value, nameof(Width));
                width = value;
            }
        }

        public double Height
        {
            get { return height; }
            private set
            {
                ValidateSide(value, nameof(Height));
                height = value;
            }
        }

        public double CalculateSurface() =>
            (2 * Length * Width) + (2 * Length * Height) + (2 * Width * Height);

        public double LateralSurfaceArea() =>
             (2 * Length * Height) + (2 * Width * Height);

        public double CalculateVolume() =>
            Length * Width * Height;

        private void ValidateSide(double side, string paramName)
        {
            if (side <= 0)
            {
                throw new ArgumentException(string.Format(INVALID_SIDE_ECEPTION_MSG,paramName));
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Surface Area - {this.CalculateSurface():f2}");
            sb.AppendLine($"Lateral Surface Area - {this.LateralSurfaceArea():f2}");
            sb.AppendLine($"Volume - {this.CalculateVolume():f2}");

            return sb.ToString().TrimEnd();
        }
    }
}
