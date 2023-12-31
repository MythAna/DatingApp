import { Photo } from "./photo";

 export interface Member {
    id: number;
    username: string;
    photourl: string;
    age: number;
    knownAs: string;
    created: Date;
    lastActive: Date;
    gender: string;
    introduction: string;
    LookingFor: string;
    interests: string;
    city: string;
    country: string;
    photos: Photo[];
 }