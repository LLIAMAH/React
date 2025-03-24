import {IProject, ITag} from "../interfaces/interfaces.ts";
import {IResult} from "../interfaces/web-interfaces.ts";

export const ROUTES = {
    PROJECTS: '/projects',
    TICKETS: '/tickets',
    TAGS: '/tags'
}

export class Client {
    private BASE_URL = 'http://localhost:5241';

    async get<T>(url: string): Promise<T> {
        const response = await fetch(url);
        const responseJson = await response.json();
        if (!response.ok) {
            throw new Error(response.statusText);
        }
        return responseJson as T;
    }

    async post<T>(url: string, data: object): Promise<T> {
        const response = await fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        })
            .then(
                resp => resp.json()
            );

        if (!response.ok) {
            throw new Error(response.statusText);
        }
        return response as T;
    }

    async put<T>(url: string, data: object): Promise<T> {
        const response = await fetch(url, {
            method: 'put',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        })
            .then(
                resp => resp.json()
            );

        if (!response.ok) {
            throw new Error(response.statusText);
        }
        return response as T;
    }

    async getProjects(): Promise<IResult<IProject[]>> {
        return await this.get<IResult<IProject[]>>(`${this.BASE_URL}${ROUTES.PROJECTS}`);
    }

    async postProject(project: IProject): Promise<IResult<IProject>> {
        return await this.post<IResult<IProject>>(`${this.BASE_URL}${ROUTES.PROJECTS}`, project);
    }

    async getTags(): Promise<IResult<ITag[]>> {
        return await this.get<IResult<ITag[]>>(`${this.BASE_URL}${ROUTES.TAGS}`);
    }
}