using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Domain.Models;
using Domain.ApiProtocol.Base;

namespace AppDatabase
{
    public class ContractFile
    {
        string path = "./contract.txt";
        public StreamWriter contractWriter;
        public ContractFile()
        {
            try
            {
                contractWriter = new StreamWriter(path);
            }
            catch
            {
                throw new Exception("Cannot create Contract file for Master data.");
            }
        }

        public void ParseAndWriteMasterData(string result)
        {
            string[] rows = result.Split('\n');
            
            
            foreach (var row in rows)
            {
                if (row.Contains("NSEFO"))
                {
                    try
                    {
                        Security security = new Security();
                        string[] columns = row.Split('|');
                        security.exchangeSegment = (ExchangeSegment)Enum.Parse(typeof(ExchangeSegment), columns[0]);
                        security.exchangeInstrumentID = int.Parse(columns[1]);
                        security.instrumentType = int.Parse(columns[2]);
                        security.name = columns[3];
                        security.Description = columns[4];
                        security.series = (Series)Enum.Parse(typeof(Series), columns[5]);
                        security.NameWithSeries = columns[6];
                        security.instrumentID = long.Parse(columns[7]);
                        security.PriceBandHigh = double.Parse(columns[8]);
                        security.PriceBandLow = double.Parse(columns[9]);
                        security.freezeQty = int.Parse(columns[10]);
                        security.tickSize = double.Parse(columns[11]);
                        security.LotSize = int.Parse(columns[12]);
                        security.UnderlyingInstrumentId = long.Parse(columns[14]);
                        security.UnderlyingIndexName = columns[15];
                        security.ContractExpiration = DateTime.ParseExact(columns[16], "yyyy-MM-ddTHH:mm:ss", null);
                        if(columns.Length>17)
                        {
                            security.StrikePrice = double.Parse(columns[17]);
                            security.OptionType = int.Parse(columns[18]);
                        }
                        Inventory.Instance().securities.Add(security);
                        Write(row);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Error in contract data parsing at {row}");
                    }
                }
            }
        }

        public void Write(string line)
        {
            contractWriter.WriteLine(line);
        }
    }
}
