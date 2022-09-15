using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Applications.GenreOperations.GetGenreDetail
{
    public class GetGenreDetailQuery
    {
        public int GenreId { get; set; }
        public readonly BookStoreDbContext _dbContext;
        public readonly IMapper _mapper;
        public GetGenreDetailQuery(BookStoreDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        public GenreDetailViewModel Handle()
        {
            var genres = _dbContext.Genres.SingleOrDefault(x=> x.IsActive && x.Id == GenreId);

            if(genres is null) 
                throw new InvalidOperationException("Kitap Türü bulunamadı.");

            return _mapper.Map<GenreDetailViewModel>(genres);
            
        }
    }

    public class GenreDetailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
    
