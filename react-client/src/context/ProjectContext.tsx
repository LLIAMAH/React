import {createContext} from "react";
import * as React from "react";
import {IProject, ITicket} from "../interfaces/interfaces.ts";

export interface IContextData {
  projects: IProject[];
  selectedProject: IProject | null;
  selectedProjectTickets: ITicket[];
}

const initialData : IContextData = {
  projects: [],
  selectedProject: null,
  selectedProjectTickets: []
}

const ProjectsContext
    = createContext<{ state: IContextData; setState: React.Dispatch<React.SetStateAction<IContextData>> } | undefined>(undefined);

export const ProjectProvider: React.FC<{ children: React.ReactNode }> = ({children}) => {
  const [state, setState] = React.useState(initialData);

  return (
    <ProjectsContext.Provider value={{state: state, setState: setState}}>
      {children}
    </ProjectsContext.Provider>
  );
}

export const useProjects = () => {
  const context = React.useContext(ProjectsContext);
  if (context === undefined) throw new Error("Cannot get context!");

  return React.useContext(ProjectsContext);
};