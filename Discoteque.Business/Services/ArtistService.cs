using System.Security;
using Discoteque.Business.IServices;
using Discoteque.Data.Models;

namespace Discoteque.Business.Services;

public class ArtistService : IArtistService
{
    private List<Artist> _artists;
    private Random random = new Random();

    public ArtistService(){
        _artists = new List<Artist>();
        BuildArtistsList(_artists);
    }

    public Task<List<Artist>> GetArtistsAsync()
    {
        return Task.FromResult<List<Artist>>(_artists);
    }

    public Task<Artist> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Artist> CreateArtistAsync(Artist artist){
        artist.Id = random.Next();
        _artists.Add(artist);
        return Task.FromResult<Artist>(_artists.Find(artistModel => artistModel.Id == artist.Id));
    }

    public Task<List<Artist>> CreateArtist(Artist artistParam)
    {
        Artist artist = new()
        {
            Id = random.Next(),
            Name = artistParam.Name,
            Label = artistParam.Label,
            IsOnTour = artistParam.IsOnTour
        };
        var artists = CreateArtistAsync(artist).Result;
        _artists.Add(artists);
        return Task.FromResult<List<Artist>>(_artists);
    }

    public Task<Artist> UpdateArtist(Artist artist)
    {
        throw new NotImplementedException();
    }

    private List<Artist> BuildArtistsList(List<Artist> artistList){
        artistList.Add(new Artist() { Id = random.Next(), Name = "Michael Jackson", Label = "Sony Music", IsOnTour = false });
        artistList.Add(new Artist() { Id = random.Next(), Name = "Steven Tyler", Label = "Columbia Records", IsOnTour = true });
        artistList.Add(new Artist() { Id = random.Next(), Name = "Freddy Mercury", Label = "Columbia Records", IsOnTour = false });
        return artistList;
    }
}