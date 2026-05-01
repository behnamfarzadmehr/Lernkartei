using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Lernkartei.Common.Enum;
using Lernkartei.Dto.Card;

namespace Lernkartei.Service.Concrete.Mapper;

public static class Mapper
{
    public static Domain.Entities.Card MapTo(this CardDto data)
    {
        return new Domain.Entities.Card
        {
            Artikle = (int)data.Artikle,
            Back = data.Back,
            CreateDateTime = data.CreateDateTime ?? DateTime.Now,
            Front = data.Front,
            Id = data.Id,
            Perfekt = data.Perfekt,
            Plural = data.Plural,
            WordTypes = data.WordTypes,
            KomParativ = data.KomParativ,
            Superlativ = data.Superlativ
        };
    }

    public static CardDto MapTo(this Domain.Entities.Card data)
    {
        return new CardDto
        {
            Artikle = (Artikle)data.Artikle,
            Back = data.Back,
            CreateDateTime = data.CreateDateTime,
            Front = data.Front,
            Id = data.Id,
            Perfekt = data.Perfekt,
            Plural = data.Plural,
            WordTypes = (WordTypes)data.WordTypes,
            KomParativ = data.KomParativ,
            Superlativ = data.Superlativ
        };
    }

    public static CardHouseDto MapTo(this Domain.Entities.CardHouse data)
    {
        return new CardHouseDto
        {
            Id = data.Id,
            ActionDate = data.ActionDate,
            CardId = data.CardId,
            House = data.House,
        };
    }

    public static Domain.Entities.CardHouse MapTo(this CardHouseDto data)
    {
        return new Domain.Entities.CardHouse
        {
            Id = data.Id,
            ActionDate = data.ActionDate,
            CardId = data.CardId,
            House = data.House,
        };
    }

    public static IList<CardDto> MapTo(this IList<Domain.Entities.Card> data)
    {
        return data.Select(s => new CardDto
        {
            Id = s.Id,
            Artikle = (Artikle)s.Artikle,
            Back = s.Back,
            CreateDateTime = s.CreateDateTime,
            Front = s.Front,
            Perfekt = s.Perfekt,
            Plural = s.Plural,
            WordTypes = (WordTypes)s.WordTypes,
            KomParativ = s.KomParativ,
            Superlativ = s.Superlativ
        }).ToList();
    }
}
