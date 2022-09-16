using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using SSI.FastConnect.DataContracts.Market.ResponseModels;

namespace SSI.FastConnect.DataContracts.Market.Response
{
    [DataContract]
    public class SecuritiesDetailsResponse : ResponseBase<SecuritiesDetailsResponseModel>
    {
        public SecuritiesDetailsResponse GetSample()
        {
            return new SecuritiesDetailsResponse
            {
                Data = new List<SecuritiesDetailsResponseModel>
                {
                    new SecuritiesDetailsResponseModel
                    {
                        RType = "SAMPLE",
                        ReportDate = DateTime.Now.ToString("dd/MM/yyyy"),
                        TotalNoSym = "1",
                        RepeatedInfo = new List<RepeatedInfo>
                        {
                            new RepeatedInfo
                            {
                                Isin = "SAMPLE",
                                Symbol = "SAMPLE",
                                SymbolName = "SAMPLE",
                                SymbolEngName = "SAMPLE",
                                SecType = "SAMPLE",
                                MarketId = "SAMPLE",
                                Exchange = "SAMPLE",
                                Issuer = "SAMPLE",
                                LotSize ="1",
                                IssueDate = DateTime.Now.ToString("dd/MM/yyyy"),
                                MaturityDate =DateTime.Now.ToString("dd/MM/yyyy"),
                                FirstTradingDate = DateTime.Now.ToString("dd/MM/yyyy"),
                                LastTradingDate = DateTime.Now.ToString("dd/MM/yyyy"),
                                ContractMultiplier = "1",
                                SettlMethod = "SAMPLE",
                                Underlying = "SAMPLE",
                                PutOrCall = "P",
                                ExercisePrice ="1",
                                ExerciseStyle = "SAMPLE",
                                ExcerciseRatio = "SAMPLE",
                                ListedShare ="1",
                                TickIncrement1 = "1",
                                TickIncrement2 = "1",
                                TickIncrement3 = "1",
                                TickIncrement4 = "1",
                                TickPrice1 = "1",
                                TickPrice2 = "1",
                                TickPrice3 = "1",
                                TickPrice4 = "1"
                            }
                            
                        }
                        
                    }
                }
            };
        }
    }
}
