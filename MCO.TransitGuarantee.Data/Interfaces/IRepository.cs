﻿namespace MCO.TransitGuarantee.Data.Interfaces
{
    using System;
    using System.Collections.Generic;
    using Models;

    public interface IRepository
    {
        DateTime DateParameter { get; set; }
        IEnumerable<Consignment_DataModel> Fetch_AllActiveConsignments(string inlandDepotList);
        IEnumerable<InvoiceHeader_DataModel> Fetch_ConsignmentInvoiceHeaders(int consignment_Number);
        IEnumerable<InvoiceDetail_DataModel> Fetch_ConsignmentInvoiceDetails(int consignment_Number, string supplier_Invoice_Number);
        bool Check_ExchangeRatesAreCurrent();
    }
}
