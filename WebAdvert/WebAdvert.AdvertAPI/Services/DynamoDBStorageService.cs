using AdvertApi.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;

namespace WebAdvert.AdvertAPI.Services
{
    public class DynamoDBStorageService : IAdvertStorageService
    {
        private readonly IMapper _mapper;

        public DynamoDBStorageService(IMapper mapper)
        {
            mapper = _mapper;
        }
        public async Task<string> Add(AdvertModel model)
        {
            var dbModel = _mapper.Map<AdvertDbModel>(model);

            dbModel.Id = new Guid().ToString();
            dbModel.CreationDateTime = DateTime.UtcNow;
            dbModel.Status = AdvertStatus.Pending;

            using(var client = new AmazonDynamoDBClient())
            {
                using (var context = new DynamoDBContext(client))
                {
                    await context.SaveAsync(dbModel);
                }
            }

            return dbModel.Id;
        }

        public Task<bool> Confirm(ConfirmAdvertModel model)
        {
            throw new NotImplementedException();
        }
    }
}
