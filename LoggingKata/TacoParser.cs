using System.ComponentModel.DataAnnotations;

namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            logger.LogInfo("Begin parsing");

            // Take your line and use line.Split(',') to split it up into an array of strings, separated by the char ','
            var cells = line.Split(',');

            // If your array.Length is less than 3, something went wrong
            if (cells.Length < 3)
            {
                // Log that and return null
                // Do not fail if one record parsing fails, return null
                logger.LogWarning("It's null!");
                return null; // TODO Implement
            }
            // grab the latitude from your array at index 0
            // grab the longitude from your array at index 1
            // grab the name from your array at index 2
            var lat = cells[0];
            var lon = cells[1];
            var name = cells[2];

            // Your going to need to parse your string as a `double`
            // which is similar to parsing a string as an `int`
            double latitude = double.Parse(lat);
            double longitude = double.Parse(lon);

            // You'll need to create a TacoBell class
            // that conforms to ITrackable
            var point = new Point();

            point.Latitude = latitude;
            point.Longitude = longitude;

            var tacoBell = new TacoBell();

            tacoBell.Name = name;
            tacoBell.Location = point;

            // Then, you'll need an instance of the TacoBell class
            // With the name and point set correctly
            // Then, return the instance of your TacoBell class
            // Since it conforms to ITrackable
            return tacoBell;
        }
    }
}