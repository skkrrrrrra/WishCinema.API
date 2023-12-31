﻿using WishCinema.Domain.Entities.Base;

namespace WishCinema.Domain.Entities;

public class Movie : BaseEntity
{
    public Movie(DateTime createdAt, DateTime updatedAt, DateTime? deletedAt) 
        : base(createdAt, updatedAt, deletedAt)
    {
    }
    public Movie() { }
    public string Title { get; set; } = null!;

    public string PosterLink { get; set; } = null!;

    public string Director { get; set; } = null!;

    public virtual ICollection<GenresMovie> GenresMovies { get; set; } = new List<GenresMovie>();

    public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();
}
