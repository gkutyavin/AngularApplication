namespace BackendApi.Dto
{
    public readonly record struct CountryDto
    {
        public int? ID { get; init; }
        public string? Name { get; init; }
        public ICollection<ProvinceDto>? Provinces { get; init; }
    }
}
