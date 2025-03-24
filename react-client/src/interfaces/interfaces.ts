export interface IProject {
    id: number | null;
    name: string;
    description: string | null;
    tickets: ITicket[] | [],
    tags: ITag[] | null;
    isSelected: boolean;
}

export interface ITag {
    id: number;
    name: string;
}

export interface ITicket {
    id: number;
    title: string;
    description: string;
    status: IStatus;
    isSelected: boolean;
}

export interface IStatus {
    id: number;
    name: string;
}

export interface IError {
  message: string;
}