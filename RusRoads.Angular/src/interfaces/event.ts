export interface Event {
    id: number
    date_start: Date,
    date_end: Date,
    event_type_id: number | null,
    description: string,
    employee_id: number
}
