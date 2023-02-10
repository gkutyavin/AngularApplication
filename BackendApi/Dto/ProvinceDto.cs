namespace BackendApi.Dto
{
    public readonly record struct ProvinceDto
    {
        public int? ID { get; init; }
        public string? Name { get; init; }
    }
}
