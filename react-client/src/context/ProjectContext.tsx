import {PROJECTS} from "../data/project.ts";
import {createContext} from "react";
import * as React from "react";
import {IProject} from "../interfaces/interfaces.ts";

const ProjectContext
    = createContext<{ state: IProject[]; setState: React.Dispatch<React.SetStateAction<IProject[]>> } | undefined>(undefined);

export const ProjectProvider: React.FC<{ children: React.ReactNode }> = ({children}) => {
    const [state, setState] = React.useState(PROJECTS);

    return (
        <ProjectContext.Provider value={{ state: state, setState: setState }}>
            {children}
        </ProjectContext.Provider>
    );
}

export function useProjects(){
    return React.useContext(ProjectContext)!;
}