using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyMusic.Core;
using MyMusic.Core.Models;
using MyMusic.Core.Services;

namespace MyMusic.Services
{
    public class ArtistService : IArtistService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ArtistService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Artist> CreateArtist(Artist newArtist)
        {
            await _unitOfWork.Artists
                .AddAsync(newArtist);
            
            return newArtist;
        }

        public async Task DeleteArtist(int id)
        {
            var artistToBeDeleted = await _unitOfWork.Artists.GetByIdAsync(id);

            if (artistToBeDeleted == null)
                throw new Exception(); // We're using this for demo purposes, but is better to have custom exceptions for this case or work with the Result pattern

            _unitOfWork.Artists.Remove(artistToBeDeleted);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Artist>> GetAllArtists()
        {
            return await _unitOfWork.Artists.GetAllAsync();
        }

        public async Task<Artist> GetArtistById(int id)
        {
            return await _unitOfWork.Artists.GetByIdAsync(id);
        }

        public async Task<Artist> UpdateArtist(int id, Artist artist)
        {
            var updatedArtist = await _unitOfWork.Artists.GetByIdAsync(id);

            if (updatedArtist == null)
                throw new Exception(); // We're using this for demo purposes, but is better to have custom exceptions for this case or work with the Result pattern

            updatedArtist.Name = artist.Name;

            await _unitOfWork.CommitAsync();

            return updatedArtist;
        }
    }
}