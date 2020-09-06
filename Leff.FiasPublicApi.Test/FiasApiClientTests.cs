using System;
using System.Linq;
using System.Threading.Tasks;
using Leff.FiasPublicApi.Models;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Leff.FiasPublicApi.Test
{
    public class FiasApiClientTests
    {
        private FiasApiClient _fiasApiClient;

        [SetUp]
        public void Setup()
        {
            _fiasApiClient = new FiasApiClient();
        }

        [TestCase("78b0d0f2-d796-4f6c-a099-9379b267afc7")]
        [TestCase("d1e0b682-f7f8-4697-b3e8-1468da2bc741")]
        public async Task ExtendedSearch_FindsFiasObjectByValidGuid_Test(string fiasGuid)
        {
            var searchRequest = new SearchRequestBase {Guid = Guid.Parse(fiasGuid)};

            var response = await _fiasApiClient.ExtendedSearchAsync(searchRequest);

            Assert.NotNull(response, "response != null");
            Assert.NotNull(response.Data, "response.Data != null");
            Assert.AreEqual(1, response.Total, "response.Total == 1");
            Assert.IsNotEmpty(response.Data, "response.Data not empty");
            Assert.AreEqual(1, response.Data.Count, "response.Data.Count == 1");
        }

        [TestCase("78b0d0f2-d796-4f6c-a099-9379b267afc7", FiasObjectLevelId.House)]
        [TestCase("d1e0b682-f7f8-4697-b3e8-1468da2bc741", FiasObjectLevelId.Apartment)]
        public async Task GetChildObjects_FindsExistingChildObjects_Test(string fiasGuid, FiasObjectLevelId levelId)
        {
            var searchRequest = new SearchRequestBase {Guid = Guid.Parse(fiasGuid)};
            var extendedSearchResponse = await _fiasApiClient.ExtendedSearchAsync(searchRequest);
            var objectDetails = extendedSearchResponse.Data.First();

            var fiasObjectList = await _fiasApiClient.GetChildObjectsAsync(objectDetails, levelId);

            Assert.NotNull(fiasObjectList, "fiasObjectList != null");
            Assert.IsNotEmpty(fiasObjectList, "fiasObjectList is not empty");
        }

        [TestCase("78b0d0f2-d796-4f6c-a099-9379b267afc7")]
        [TestCase("d1e0b682-f7f8-4697-b3e8-1468da2bc741")]
        public async Task ExtendedSearch_ReturnsSameObjectByGuidAndId_Test(string fiasGuid)
        {
            var searchByGuidRequest = new SearchRequestBase {Guid = Guid.Parse(fiasGuid)};
            var responseByGuid = await _fiasApiClient.ExtendedSearchAsync(searchByGuidRequest);
            var objectByGuid = responseByGuid.Data.First();

            var objectHierarchy = new FiasHierarchy(objectByGuid.LevelId, objectByGuid.ObjectId);
            var searchRequest = new MunicipalSearchRequest {Hierarchy = objectHierarchy};

            var response = await _fiasApiClient.ExtendedSearchAsync(searchRequest);

            Assert.NotNull(response, "response != null");
            Assert.NotNull(response.Data, "response.Data != null");
            Assert.AreEqual(1, response.Total, "response.Total == 1");
            Assert.IsNotEmpty(response.Data, "response.Data not empty");
            Assert.AreEqual(1, response.Data.Count, "response.Data.Count == 1");

            var objectByHierarchy = response.Data.First();
            Assert.AreEqual(objectByGuid.Id, objectByHierarchy.Id, "objectByGuid.Id == objectByHierarchy.Id");
            Assert.AreEqual(objectByGuid.Name, objectByHierarchy.Name, "objectByGuid.Name == objectByHierarchy.Name");
            Assert.AreEqual(objectByGuid.LevelId, objectByHierarchy.LevelId, "objectByGuid.LevelId == objectByHierarchy.LevelId");
            Assert.AreEqual(objectByGuid.ObjectId, objectByHierarchy.ObjectId, "objectByGuid. == objectByHierarchy.");
            Assert.AreEqual(objectByGuid.Guid, objectByHierarchy.Guid, "objectByGuid.Guid == objectByHierarchy.Guid");
            Assert.AreEqual(objectByGuid.IsActual, objectByHierarchy.IsActual, "objectByGuid.IsActual == objectByHierarchy.IsActual");
            Assert.AreEqual(objectByGuid.IsActive, objectByHierarchy.IsActive, "objectByGuid.IsActive == objectByHierarchy.IsActive");
        }
    }
}