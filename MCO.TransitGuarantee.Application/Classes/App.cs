namespace MCO.TransitGuarantee.Application.Classes
{
    using Interfaces;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    using System.Linq;
    using MCO.TransitGuarantee.Data.Interfaces;

    public class App : IApp
    {
        private readonly ILog logger;
        private readonly IFileWriter fileWriter;
        private readonly IDataHandler dataHandler;
        private readonly IExchangeRateHandler exchangeRateHandler;
        private readonly IRepository repo;

        public App(ILog logger, IFileWriter dataWriter, IDataHandler dataHandler, IExchangeRateHandler exchangeRateHandler, IRepository repo)
        {
            this.logger = logger;
            this.fileWriter = dataWriter;
            this.dataHandler = dataHandler;
            this.exchangeRateHandler = exchangeRateHandler;
            this.repo = repo;
        }

        public void Run(DateTime date)
        {
            try
            {
                //parameter for sql.
                repo.DateParameter = date;
               

                logger.Info("Transit Guarantee Started");
                

                #region Run Exchange rate handler

                exchangeRateHandler.EnsureExchangeRatesAreCurrent();
                
                #endregion

                #region Return Consignment Data
                IEnumerable<Consignment> consignmentData = dataHandler.Return_AllActiveConsignments_ToViewModel();
                consignmentData = consignmentData.OrderBy(x => x.Consignment_Delivery_Status)
                                                 .ThenByDescending(x => x.ETA_At_Port)
                                                 .ThenBy(x => x.Consignment_Number);
               
                #endregion

#region Write to CSV
                fileWriter.Write_AllData_ToCsv(consignmentData, date.ToString("yyyyMMdd"));
#endregion
                
                logger.Info("Transit Guarantee Ended");
            }
            catch(Exception ex)
            {
                logger.Error(ex.Message);
                logger.Error(ex.StackTrace);
            }
        }
    }
}
