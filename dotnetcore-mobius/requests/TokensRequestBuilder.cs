using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using dotnetcore_mobius.responses;

namespace dotnetcore_mobius.requests
{
    public class TokensRequestBuilder : RequestBuilder<TokensRequestBuilder>
    {
        public enum TokenType { Erc20, Stellar }

        public TokensRequestBuilder(HttpClient httpClient, Uri serverUri)
            : base(httpClient, serverUri, "tokens")
        {

        }

        public TokensRequestBuilder RegisterTokens(TokenType tokenType, string name, string symbol, string issuer)
        {
            SetSegments("tokens", "register");
            SetRequestType(RequestType.Post);
            UriBuilder.SetQueryParam("token_type", tokenType.ToString().ToLower());
            UriBuilder.SetQueryParam("name", name);
            UriBuilder.SetQueryParam("symbol", symbol);
            UriBuilder.SetQueryParam("issuer", issuer);

            return this;
        }

        public CreateAddressRequest CreateAddress(string tokenUid)
        {
            SetSegments("tokens", "create_address");
            SetRequestType(RequestType.Post);
            UriBuilder.SetQueryParam("token_uid", tokenUid);

            return new CreateAddressRequest(this);
        }


        public RegisterAddressRequest RegisterAddress(string tokenUid, string address)
        {
            SetSegments("tokens", "register_address");
            SetRequestType(RequestType.Post);
            UriBuilder.SetQueryParam("token_uid", tokenUid);
            UriBuilder.SetQueryParam("address", address);

            return new RegisterAddressRequest(this);
        }

        public GetAddressBalanceRequest GetAddressBalance(string tokenUid, string address)
        {

            SetSegments("tokens", "balance");
            UriBuilder.SetQueryParam("token_uid", tokenUid);
            UriBuilder.SetQueryParam("address", address);

            return new GetAddressBalanceRequest(this);
        }

        public CreateTransferRequest CreateTransfer(string tokenAddressUid, string addressTo, string numberOfTokens)
        {
            SetSegments("tokens", "transfer", "managed");
            SetRequestType(RequestType.Post);
            UriBuilder.SetQueryParam("token_address_uid", tokenAddressUid);
            UriBuilder.SetQueryParam("address_to", addressTo);
            UriBuilder.SetQueryParam("num_tokens", numberOfTokens);

            return new CreateTransferRequest(this);
        }

        public GetTransferInfoRequest GetTransferInfo(string tokenAddressTransferUid)
        {
            SetSegments("tokens", "transfer", "info");
            UriBuilder.SetQueryParam("token_address_transfer_uid", tokenAddressTransferUid);

            return new GetTransferInfoRequest(this);
        }

        public async Task<TokensResponse> Execute()
        {
            return await Execute<TokensResponse>(BuildUri());
        }

        public class CreateAddressRequest
        {
            private readonly RequestBuilder<TokensRequestBuilder> _tokensRequestBuilder;

            public CreateAddressRequest(RequestBuilder<TokensRequestBuilder> tokensREquestBuilder)
            {
                _tokensRequestBuilder = tokensREquestBuilder;
            }
            
            public async Task<CreateAddressResponse> Execute()
            {
                return await _tokensRequestBuilder.Execute<CreateAddressResponse>(_tokensRequestBuilder.BuildUri());
            }
        }

        public class RegisterAddressRequest
        {
            private readonly RequestBuilder<TokensRequestBuilder> _tokensRequestBuilder;

            public RegisterAddressRequest(RequestBuilder<TokensRequestBuilder> tokensREquestBuilder)
            {
                _tokensRequestBuilder = tokensREquestBuilder;
            }

            public async Task<RegisterAddressResponse> Execute()
            {
                return await _tokensRequestBuilder.Execute<RegisterAddressResponse>(_tokensRequestBuilder.BuildUri());
            }
        }

        public class GetAddressBalanceRequest
        {
            private readonly RequestBuilder<TokensRequestBuilder> _tokensRequestBuilder;

            public GetAddressBalanceRequest(RequestBuilder<TokensRequestBuilder> tokensREquestBuilder)
            {
                _tokensRequestBuilder = tokensREquestBuilder;
            }

            public async Task<GetAddressBalanceResponse> Execute()
            {
                return await _tokensRequestBuilder.Execute<GetAddressBalanceResponse>(_tokensRequestBuilder.BuildUri());
            }
        }

        public class CreateTransferRequest
        {
            private readonly RequestBuilder<TokensRequestBuilder> _tokensRequestBuilder;

            public CreateTransferRequest(RequestBuilder<TokensRequestBuilder> tokensREquestBuilder)
            {
                _tokensRequestBuilder = tokensREquestBuilder;
            }

            public async Task<CreateTransferResponse> Execute()
            {
                return await _tokensRequestBuilder.Execute<CreateTransferResponse>(_tokensRequestBuilder.BuildUri());
            }
        }

        public class GetTransferInfoRequest
        {
            private readonly RequestBuilder<TokensRequestBuilder> _tokensRequestBuilder;

            public GetTransferInfoRequest(RequestBuilder<TokensRequestBuilder> tokensREquestBuilder)
            {
                _tokensRequestBuilder = tokensREquestBuilder;
            }

            public async Task<GetTransferInfoResponse> Execute()
            {
                return await _tokensRequestBuilder.Execute<GetTransferInfoResponse>(_tokensRequestBuilder.BuildUri());
            }
        }
    }
}
