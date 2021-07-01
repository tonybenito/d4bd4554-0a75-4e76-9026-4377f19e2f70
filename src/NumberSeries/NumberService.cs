using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NumberSeries
{
    public class NumberService : INumberService
    {      

        public string GetBiggestSeries(string inputSeries)
        {
            StringBuilder resultSeries = new StringBuilder();
            string[] words = inputSeries.Split(' ');
            List<int> series = new List<int>();
            List<NumberSeriesDto> numberSeries = new List<NumberSeriesDto>();
            int size = 0;


            if (string.IsNullOrEmpty(inputSeries))
            {
                return string.Empty;
            }


            foreach (var word in words)
            {
                series.Add(Convert.ToInt32(word));
            }

            // extraction of biggest series           
            for (int i = 0; i < series.Count; i++)
            {
                if (i == series.Count - 1)
                {
                    if (series[i] > series[i - 1])
                    {
                        resultSeries.Append($"{series[i]} ");
                        size++;
                        numberSeries.Add(new NumberSeriesDto { Series = resultSeries.ToString(), Size = size });
                    }

                }
                else if (series[i + 1] > series[i])
                {
                    resultSeries.Append($"{series[i]} ");
                    size++;
                }
                else
                {
                    resultSeries.Append($"{series[i]} ");
                    size++;
                    numberSeries.Add(new NumberSeriesDto { Series = resultSeries.ToString(), Size = size });

                    resultSeries.Clear();
                    size = 0;
                    continue;
                }
            }


            return numberSeries.OrderByDescending(x => x.Size).First().Series.Trim();
        }

       
    }
    public class NumberSeriesDto
    {
        public string Series { get; set; }
        public int Size { get; set; }
    }
}
