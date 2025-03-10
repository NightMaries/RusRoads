import { Subdivision } from "./subdivision"

export interface Employee {
    id:number,
    fio: string,
    date_born: Date
    cabinet: string
    job_number: string
    email:string
    position:string
    subdivision_id:number
    subdivision: Subdivision|null
    personal_phone: string
    leader_id: string|null,
    helper_id: string|null,
    dismiss_date: Date|null 
}
