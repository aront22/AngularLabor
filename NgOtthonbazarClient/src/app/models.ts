export enum AdvertisementType {
    flat = 0,
    house = 1,
    holidayHouse = 2,
    buildingPlot = 3
}
export interface City {
    id: number,
    zip: string,
    name: string
}

export interface Advertisement {
    id: number;
    address: string,
    advertisementType: AdvertisementType,
    buildDate: number,
    cityId: number;
    city: City;
    description: string,
    halfRoom: number,
    room: number,
    imageUrl: string,
    price: number,
    size: number,
}