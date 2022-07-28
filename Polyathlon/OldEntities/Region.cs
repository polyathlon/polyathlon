﻿using CouchDB.Driver.Types;

namespace Polyathlon.Entities
{
    public class Region : CouchDocument
    {
        public string? Name { get; set; }
        public string? ShortName { get; set; }

        public Region(string name = "", string shortName = "")
        {
            Name = name;
            ShortName = shortName;
        }

        public static string[] Regions
        {
            get
            {
                return new string[]
                {
                    "Республика Адыгея",
                    "Республика Башкортостан",
                    "Республика Бурятия",
                    "Республика Алтай",
                    "Республика Дагестан",
                    "Республика Ингушетия",
                    "Кабардино-Балкарская Республика",
                    "Республика Калмыкия",
                    "Карачаево-Черкесская Республика",
                    "Республика Карелия",
                    "Республика Коми",
                    "Республика Марий Эл",
                    "Республика Мордовия",
                    "Республика Саха (Якутия)",
                    "Республика Северная Осетия - Алания",
                    "Республика Татарстан",
                    "Республика Тыва (Тува)",
                    "Удмуртская Республика",
                    "Республика Хакасия",
                    "Чеченская Республика",
                    "Чувашская Республика",
                    "Алтайский край",
                    "Краснодарский край",
                    "Красноярский край",
                    "Приморский край",
                    "Ставропольский край",
                    "Хабаровский край",
                    "Амурская область",
                    "Архангельская область",
                    "Астраханская область",
                    "Белгородская область",
                    "Брянская область",
                    "Владимирская область",
                    "Волгоградская область",
                    "Вологодская область",
                    "Воронежская область",
                    "Ивановская область",
                    "Иркутская область",
                    "Калининградская область",
                    "Калужская область",
                    "Камчатская край",
                    "Кемеровская область",
                    "Кировская область",
                    "Костромская область",
                    "Курганская область",
                    "Курская область",
                    "Ленинградская область",
                    "Липецкая область",
                    "Магаданская область",
                    "Московская область",
                    "Мурманская область",
                    "Нижегородская область",
                    "Новгородская область",
                    "Новосибирская область",
                    "Омская область",
                    "Оренбургская область",
                    "Орловская область",
                    "Пензенская область",
                    "Пермский край",
                    "Псковская область",
                    "Ростовская область",
                    "Рязанская область",
                    "Самарская область",
                    "Саратовская область",
                    "Сахалинская область",
                    "Свердловская область",
                    "Смоленская область",
                    "Тамбовская область",
                    "Тверская область",
                    "Томская область",
                    "Тульская область",
                    "Тюменская область",
                    "Ульяновская область",
                    "Челябинская область",
                    "Забайкальский край",
                    "Ярославская область",
                    "Москва",
                    "Санкт-Петербург",
                    "Еврейская автономная область",
                    "Ненецкий автономный округ",
                    "Ханты-Мансийский автономный округ",
                    "Чукотский автономный округ",
                    "Ямало-Ненецкий автономный округ",
                    "Kazakhstan",
                    "Russia",
                    "Ukraine",
                    "Belarus",
                    "Estonia",
                    "Latvia",
                    "Finland",
                    "Germany",
                    "Sweden",
                    "Italy",
                    "Norway",
                    "United States of America",
                    "Canada",
                    "Poland",
                    "France",
                    "Slovenia",
                    "Japan",
                    "People\"s Republic of China",
                    "Switzerland",
                    "Armenia",
                    "Austria",
                    "Korea",
                };
            }
        }
    }
}