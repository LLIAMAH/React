import {IProject} from "../interfaces/interfaces.ts";

export const PROJECTS: IProject[] = [
    {
        id: 1,
        name: 'Project 1',
        description: 'Project 1 description',
        tickets: [
            {
                id: 1,
                title: 'Ticket 1',
                description: 'Ticket 1 description',
                status: {
                    id: 1,
                    name: 'Pending'
                }
            },
            {
                id: 2,
                title: 'Ticket 2',
                description: 'Ticket 2 description',
                status: {
                    id: 1,
                    name: 'Pending'
                }
            },
            {
                id: 3,
                title: 'Ticket 3',
                description: 'Ticket 3 description',
                status: {
                    id: 1,
                    name: 'Pending'
                }
            }
        ]
    },
    {
        id: 2,
        name: 'Project 2',
        description: 'Project 2 description',
        tickets: [
            {
                id: 4,
                title: 'Ticket 4',
                description: 'Ticket 4 description',
                status: {
                    id: 1,
                    name: 'Pending'
                }
            },
            {
                id: 5,
                title: 'Ticket 5',
                description: 'Ticket 5 description',
                status: {
                    id: 1,
                    name: 'Pending'
                }
            },
            {
                id: 6,
                title: 'Ticket 6',
                description: 'Ticket 3 description',
                status: {
                    id: 1,
                    name: 'Pending'
                }
            }
        ]
    },
    {
        id: 3,
        name: 'Project 3',
        description: 'Project 3 description',
        tickets: [
            {
                id: 7,
                title: 'Ticket 7',
                description: 'Ticket 7 description',
                status: {
                    id: 1,
                    name: 'Pending'
                }
            },
            {
                id: 8,
                title: 'Ticket 8',
                description: 'Ticket 8 description',
                status: {
                    id: 1,
                    name: 'Pending'
                }
            },
            {
                id: 9,
                title: 'Ticket 9',
                description: 'Ticket 9 description',
                status: {
                    id: 1,
                    name: 'Pending'
                }
            }
        ]
    }
];