namespace LMS.UnitTest.Fixtures
{
    public static class AuthorFixture
    {
        public static ServiceResponse<IEnumerable<GetAuthorViewModel>> GetListOfAuthors()
        {
            var response = new ServiceResponse<IEnumerable<GetAuthorViewModel>>();

            response.ResponseData = new List<GetAuthorViewModel>()
            {
                new GetAuthorViewModel()
                {
                    Id = 1,
                    FirstName = "Name 1",
                    LastName = "LastName 1",
                    Nationality = "MOZ"
                },
                new GetAuthorViewModel()
                {
                    Id = 2,
                    FirstName = "Name 2",
                    LastName = "LastName 2",
                    Nationality = "MOZ"
                },
                new GetAuthorViewModel()
                {
                    Id = 3,
                    FirstName = "Name 3",
                    LastName = "LastName 3",
                    Nationality = "MOZ"
                },
                new GetAuthorViewModel()
                {
                    Id = 4,
                    FirstName = "Name 4",
                    LastName = "LastName 4",
                    Nationality = "MOZ"
                }
            };

            return response;
        }

        public static ServiceResponse<GetAuthorViewModel> GetById(int id)
        {
            var serviceResponse = new ServiceResponse<GetAuthorViewModel>();
            var list = GetListOfAuthors();

            var response = list.ResponseData?.FirstOrDefault(x => x.Id == id);
            serviceResponse.ResponseData = response;

            return serviceResponse;
        }

        public static ServiceResponse<GetAuthorViewModel> GetByName(string name)
        {
            var serviceResponse = new ServiceResponse<GetAuthorViewModel>();
            var list = GetListOfAuthors();

            var response = list.ResponseData?.FirstOrDefault(x => x.FirstName.Contains(name) || x.LastName.Contains(name));
            serviceResponse.ResponseData = response;

            return serviceResponse;
        }

        public static ServiceResponse<GetAuthorViewModel> GetByNationality(string nationality)
        {
            var serviceResponse = new ServiceResponse<GetAuthorViewModel>();
            var list = GetListOfAuthors();

            var response = list.ResponseData?.FirstOrDefault(x => x.Nationality == nationality);
            serviceResponse.ResponseData = response;

            return serviceResponse;
        }

        public static ServiceResponse<GetAuthorViewModel> Add()
        {
            var serviceResponse = new ServiceResponse<GetAuthorViewModel>();
            GetAuthorViewModel response = new GetAuthorViewModel()
            {
                Id = 5,
                FirstName = "Name 5",
                LastName = "LastName 5",
                Nationality = "MOZ"
            };

            serviceResponse.ResponseData = response;

            return serviceResponse;
        }

        public static ServiceResponse<bool> Update()
        {
            var serviceResponse = new ServiceResponse<bool>();
            GetAuthorViewModel response = new GetAuthorViewModel()
            {
                Id = 5,
                FirstName = "Name 5",
                LastName = "LastName 5",
                Nationality = "MOZ"
            };

            serviceResponse.Succeeded = true;

            return serviceResponse;
        }

        public static ServiceResponse<bool> Delete()
        {
            var serviceResponse = new ServiceResponse<bool>();

            serviceResponse.Succeeded = true;

            return serviceResponse;
        }
    }
}
