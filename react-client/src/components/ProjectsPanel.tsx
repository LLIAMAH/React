import {IContextData, useProjects} from "../context/ProjectContext.tsx";
import {IProject, ITag} from "../interfaces/interfaces.ts";
import {useRef, useState} from "react";
import {ProjectNewModal} from "./ProjectNewModal.tsx";
import {UniversalModal} from "./UniversalModal.tsx";
import {Form} from "react-bootstrap";

interface IError {
    message: string;
}

export default function ProjectsPanel() {
  const {state, setState} = useProjects()!;
  const [showModal, setShowModal] = useState(false);
  const [error, setError] = useState<IError | undefined>(undefined);
  const modalRef = useRef<HTMLInputElement | null>(null);
  const modalErrorRef = useRef<HTMLDivElement | null>(null);

  function handleAddProject() {
    if (modalRef) {
      setShowModal(true);
    }
  }

  const addProject = (data: { name: string; tags: string[] }) => {
    if (data.name.trim()) {
      clearSelections(state);

      const projectNew = {
        id: state.projects.length + 1,
        name: data.name,
        description: null,
        tickets: [],
        tags: data.tags.map(tagName => ({id: 0, name: tagName} as ITag)),
        isSelected: true
      };

      setState({
        ...state,
        projects: [...state.projects, projectNew],
        selectedProject: projectNew,
        selectedProjectTickets: []
      });
      setShowModal(false);
    }
  };

  const isSingleProject = state.projects.length == 1;
  if (isSingleProject) {
    state.projects[0].isSelected = true;
  }

  const clearSelections = (state: IContextData) => {
    state.projects.forEach((value: IProject) => {
      value.isSelected = false;
    })
  }

  const selectProject = (id: number) => {
    //clearSelections(state);

    const projects = state.projects.map(project => ({
      ...project,
      isSelected: project.id === id,
    }));

    console.log("State projects");
    console.table(state.projects);
    console.log("Projects new");
    console.table(projects);

    setState({
      ...state,
      projects: projects,
      selectedProject: projects.find(p => p.id === id)!,
      selectedProjectTickets: [...projects.find(p => p.id === id)!.tickets]
    });
  }

  return (
    <>
      <div className="row mt-2">
        <div className="col text-end">
          <button className="btn btn-primary" onClick={handleAddProject}>+</button>
        </div>
      </div>
      <ul className="list-group mt-2">
        {state.projects.map((project: IProject) => {
          return (
            <li key={project.id}
                className={(project.isSelected ? "list-group-item active" : "list-group-item")}
            >
              <span>{project.name}</span>
              <button className="btn btn-primary btn-sm float-end" onClick={() => selectProject(project.id!)}>Select
              </button>
            </li>
          )
        })}
      </ul>
      <UniversalModal show={error != undefined}
                      handleClose={() => setError(undefined)}
                      ref={modalErrorRef}
                      title="Error!"
      >
        <Form.Label>{error?.message}</Form.Label>
      </UniversalModal>
      <ProjectNewModal
        ref={modalRef}
        show={showModal}
        handleClose={() => setShowModal(false)}
        onConfirm={addProject}
        title="Создать новый проект"
      />
    </>
  );
}