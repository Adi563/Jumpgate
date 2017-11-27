namespace Jumpgate.Database
{
    [System.Runtime.Serialization.DataContract]
    public class Item
    {
        [System.Runtime.Serialization.DataMember(EmitDefaultValue = false, IsRequired = true, Name = "item_id", Order = 1)]
        public uint Id { get; set; }
        [System.Runtime.Serialization.DataMember(EmitDefaultValue = false, IsRequired = true, Name = "name", Order = 2)]
        public string Name { get; set; }
        [System.Runtime.Serialization.DataMember(EmitDefaultValue = false, IsRequired = true, Name = "price", Order = 3)]
        public uint Price { get; set; }
        [System.Runtime.Serialization.DataMember(EmitDefaultValue = false, IsRequired = true, Name = "amount", Order = 4)]
        public uint Amount { get; set; }
        [System.Runtime.Serialization.DataMember(EmitDefaultValue = false, IsRequired = true, Name = "station_name", Order = 5)]
        public string StationName { get; set; }
        [System.Runtime.Serialization.DataMember(EmitDefaultValue = false, IsRequired = true, Name = "group_name", Order = 6)]
        public string GroupName { get; set; }
    }
}