using System.Collections.Generic;
using System.Linq;
using ZooManagement.Models.Database;
using ZooManagement.Request;

namespace ZooManagement.Models.Response
{
    public class SearchResponse<T>
    {
        private readonly string _path;
        private readonly string _filters;
        
        public IEnumerable<T> Animals { get; }
        public int TotalNumberOfItems { get; }
        public int Page { get; }
        public int PageSize { get; }

        public string NextPage => !HasNextPage() ? null : $"/{_path}?page={Page + 1}&pageNumber={PageSize}{_filters}";

        public string PreviousPage => Page <= 1 ? null : $"/{_path}?page={Page - 1}&pageNumber={PageSize}{_filters}";

        public SearchResponse(SearchRequest search, IEnumerable<T> animals, int totalNumberOfItems, string path)
        {
            Animals = animals;
            TotalNumberOfItems = totalNumberOfItems;
            Page = search.Page;
            PageSize = search.PageSize;
            _path = path;
           
        }
        
        private bool HasNextPage()
        {
            return Page * PageSize < TotalNumberOfItems;
        }
    }

    public class AnimalListResponse : SearchResponse<AnimalResponse>
    {
        private AnimalListResponse(SearchRequest search, IEnumerable<AnimalResponse> animals, int totalNumberOfItems) 
            : base(search, animals, totalNumberOfItems, "animals") { }

        public static AnimalListResponse Create(SearchRequest search, IEnumerable<Animal> animals, int totalNumberOfItems)
        {
            var animalModels = animals.Select(animal => new AnimalResponse(animal));
            return new AnimalListResponse(search, animalModels, totalNumberOfItems);
        }
    }
    
    // public class UserListResponse : ListResponse<UserResponse>
    // {
    //     private UserListResponse(SearchRequest search, IEnumerable<UserResponse> items, int totalNumberOfItems) 
    //         : base(search, items, totalNumberOfItems, "users") { }
        
    //     public static UserListResponse Create(SearchRequest search, IEnumerable<User> users, int totalNumberOfItems)
    //     {
    //         var userModels = users.Select(user => new UserResponse(user));
    //         return new UserListResponse(search, userModels, totalNumberOfItems);
    //     }
    // }
    
    // public class InteractionListResponse : ListResponse<InteractionResponse>
    // {
    //     private InteractionListResponse(SearchRequest search, IEnumerable<InteractionResponse> items, int totalNumberOfItems) 
    //         : base(search, items, totalNumberOfItems, "interactions") { }
        
    //     public static InteractionListResponse Create(SearchRequest search, IEnumerable<Interaction> interactions, int totalNumberOfItems)
    //     {
    //         var interactionModels = interactions.Select(i => new InteractionResponse(i));
    //         return new InteractionListResponse(search, interactionModels, totalNumberOfItems);
    //     }
    // }
}