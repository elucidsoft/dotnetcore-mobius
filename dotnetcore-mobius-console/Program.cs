using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using dotnetcore_mobius;
using dotnetcore_mobius.requests;

namespace dotnetcore_mobius_console
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            using (Server server = new Server("https://mobius.network/api/v1", "<<SECRET_KEY>>"))
            {
                //var app_uid = "<<APP_UID>>";
                //var datafeed_uid = "<<DATAFEED_UID>>";
                //var email = "<<EMAIL>>";

                //var balance = await server.AppStore.GetBalance(app_uid, email)
                //    .Execute();

                //var use = await server.AppStore.UseBalance(app_uid, email, "1")
                //    .Execute();

                //var datafeed = await server.DataFeed.GetDataFeed(datafeed_uid)
                //    .Execute();


                //var dataPoint = await server.DataFeed.CreateDataPoint(datafeed_uid, new Dictionary<string, string> { { "temperature", "95" } })
                //    .Execute();

                var registerTokens = await server.Tokens.RegisterTokens(TokensRequestBuilder.TokenType.Erc20, "Augur", "REP", "0xE94327D07Fc17907b4DB788E5aDf2ed424adDff6")
                    .Execute();

                var createAddress = await server.Tokens.CreateAddress(registerTokens.Uid)
                    .Execute();

                var registerAddress = await server.Tokens.RegisterAddress(registerTokens.Uid, createAddress.Address)
                    .Execute();

                var addressBalance = await server.Tokens.GetAddressBalance(registerTokens.Uid, createAddress.Address)
                   .Execute();

            }

        }
    }
}
