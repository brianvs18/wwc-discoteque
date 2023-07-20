using Discoteque.Data.Models;

namespace Discoteque.Business.IServices;

public interface IArtistService{
    Task<List<Artist>> GetArtistsAsync();
    Task<Artist> GetById(int id);
    Task<Artist> CreateArtistAsync(Artist artist);
    Task<List<Artist>> CreateArtist(Artist artist);
    Task<Artist> UpdateArtist(Artist artist);
}