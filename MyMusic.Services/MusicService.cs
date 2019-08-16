using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyMusic.Core;
using MyMusic.Core.Models;
using MyMusic.Core.Services;

namespace MyMusic.Services
{
    public class MusicService : IMusicService
    {
        private readonly IUnitOfWork _unitOfWork;
        public MusicService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Music> CreateMusic(Music newMusic)
        {
            await _unitOfWork.Musics.AddAsync(newMusic);
            await _unitOfWork.CommitAsync();
            return newMusic;
        }

        public async Task DeleteMusic(int id)
        {
            var musicToBeDeleted = await _unitOfWork.Musics.GetByIdAsync(id);

            if (musicToBeDeleted == null)
                throw new Exception(); // We're using this for demo purposes, but is better to have custom exceptions for this case or work with the Result pattern

            _unitOfWork.Musics.Remove(musicToBeDeleted);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Music>> GetAllWithArtist()
        {
            return await _unitOfWork.Musics
                .GetAllWithArtistAsync();
        }

        public async Task<Music> GetMusicById(int id)
        {
            return await _unitOfWork.Musics
                .GetWithArtistByIdAsync(id);
        }

        public async Task<IEnumerable<Music>> GetMusicsByArtistId(int artistId)
        {
            return await _unitOfWork.Musics
                .GetAllWithArtistByArtistIdAsync(artistId);
        }

        public async Task<Music> UpdateMusic(int id, Music music)
        {
            var updatedMusic = await _unitOfWork.Musics.GetByIdAsync(id);

            if (updatedMusic == null)
                throw new Exception(); // We're using this for demo purposes, but is better to have custom exceptions for this case or work with the Result pattern

            updatedMusic.Name = music.Name;
            updatedMusic.ArtistId = music.ArtistId;

            await _unitOfWork.CommitAsync();

            return updatedMusic;
        }
    }
}