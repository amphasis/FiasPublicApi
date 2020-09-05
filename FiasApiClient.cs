using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Leff.FiasPublicApi
{
    public class FiasApiClient
    {
        private const string BaseUrl = "https://fias.nalog.ru/";

        private readonly HttpClient _httpClient;

        public FiasApiClient() : this(new HttpClient())
        {
        }

        public FiasApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(BaseUrl);
        }

        public void A()
        {
            /*
             * GetRegions (levelId 1)
             * GetDistricts (levelId 2) (только административное деление)
             * GetMunDistricts (levelId 3) (только муниципальное деление)
             * Get(Mun)CitySettlements (levelId 4)
             * Get(Mun)Cities (levelId 5)
             * Get(Mun)Settlements (levelId 6)
             * Get(Mun)PlanStructures (levelId 7)
             * Get(Mun)Streets (levelId 8)
             * Get(Mun)Steads (levelId 9)
             * Get(Mun)Houses (levelId 10)
             * GetApartments (levelId 11)
             * GetRooms (levelId 12)
             * GetCarPlaces (levelId 17)
             */
            
            /*
            isMunHierarchy=true/false
            regionId=454811
            districtId=
            munDistrictId= 
            citySettlementId=
            cityId=
            settlementId=435054
            planStructId=
            streetId=95787681
            houseId=
            apartmentId=
            */
        }
    }
}
