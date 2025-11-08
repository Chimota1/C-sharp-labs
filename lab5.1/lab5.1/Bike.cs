using System.IO;

namespace lab5._1
{
    public partial class Bike
    {
        private string mark;
        private string name;
        private string year;
        private string color;
        private string wheelDiameter;
        private string heightOfSaddle;
        private string typeOfFrame;
        private string path = @"D:\PKPZ\C-sharp-labs\lab5.1\lab5.1\data.txt";

       public Bike()
        {
            mark = "Unknown";
            name = "Unknown";
            year = "0";
            color = "Unknown";
            wheelDiameter = "0";
            heightOfSaddle = "0";
            typeOfFrame = "Unknown";
        }
        
        public void SetMark(string mark)
        {
            this.mark = mark;
            File.AppendAllText(path, this.mark + " ");
        }

        public void SetName(string name)
        {
            this.name = name;
            File.AppendAllText(path, this.name + " ");
        }

        public void SetYear(string year)
        {
            this.year = year;
            File.AppendAllText(path, this.year + " ");
        }

        public void SetColor(string color)
        {
            this.color = color;
            File.AppendAllText(path, this.color + " ");
        }

        public void SetWheelDiameter(string wheelDiameter)
        {
            this.wheelDiameter = wheelDiameter;
            File.AppendAllText(path, this.wheelDiameter + " ");
        }

        public void SetHeightOfSaddle(string heightOfSaddle)
        {
            this.heightOfSaddle = heightOfSaddle;
            File.AppendAllText(path, this.heightOfSaddle + " ");
        }

        public void SetTypeOfFrame(string typeOfFrame)
        {
            this.typeOfFrame = typeOfFrame;
            File.AppendAllText(path, this.typeOfFrame);
        }
        
        public string GetMark()
        {
            return mark;
        }

        public string GetName()
        {
            return name;
        }

        public string GetYear()
        {
            return year;
        }

        public string GetColor()
        {
            return color;
        }

        public string GetWheelDiameter()
        {
            return wheelDiameter;
        }

        public string GetHeightOfSaddle()
        {
            return heightOfSaddle;
        }

        public string GetTypeOfFrame()
        {
            return typeOfFrame;
        }

        public string RadiusOfWheel()
        {
            int radiusInt = Int32.Parse(wheelDiameter)/2;
            return radiusInt.ToString();
        }

        public string FullInfo()
        {
            return mark + " " + name.ToString() + " " + year + " " + color; 
        }

        public string Atributtes()
        {
            return wheelDiameter.ToString() + " " + heightOfSaddle + " " + typeOfFrame;
        }
    }
};