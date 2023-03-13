using AutoMapper;
using Nest;
using Store.Application.Interfaces;
using Store.Application.Models.Products;
using Store.Domain.Entities;
using Store.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services
{
    public class SearchService : ISearchService
    {
        private readonly IElasticClient _elasticClient;
        private readonly IMapper _mapper;

        public SearchService(IElasticClient elasticClient, IMapper mapper)
        {
            _elasticClient = elasticClient;
            _mapper = mapper;
        }

        public async Task<List<ProductDto>> SearchAsync(string keyword, CancellationToken cancellationToken = default)
        {
            var products = (await _elasticClient.SearchAsync<Product>(
                        s => s.Query(
                            q => q.QueryString(
                                d => d.Query('*' + keyword + '*')
                            )).Size(5000), cancellationToken)).Documents;

            var result = _mapper.Map<List<ProductDto>>(products);

            return result;
        }
    }
}
