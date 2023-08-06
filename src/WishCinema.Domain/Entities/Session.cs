﻿using WishCinema.Domain.Entities.Base;

namespace WishCinema.Domain.Entities;

public class Session : BaseEntity
{
    public long CinemaId { get; set; }

    public long HallId { get; set; }

    public long FilmId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public virtual Cinema Cinema { get; set; } = null!;

    public virtual Movie Film { get; set; } = null!;

    public virtual Hall Hall { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
