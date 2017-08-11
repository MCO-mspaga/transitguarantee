namespace MCO.TransitGuarantee.Application
{
    using Interfaces;
    using System;
    using System.Globalization;

    class TransitGuarantee
    {
        static void Main(string[] args)
        {
            CompositionRoot.Wire(new ApplicationModule());

            var app = CompositionRoot.Resolve<IApp>();

            if(args.Length > 0)
            {
                app.Run(DateTime.ParseExact(args[0],
                                 "yyyyMMdd",
                                  CultureInfo.InvariantCulture));
            }
            else
            {
                app.Run(DateTime.Now.Date);
            }
        }
    }
}
