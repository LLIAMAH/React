import {useProjects} from "../context/ProjectContext.tsx";
import {IProject} from "../interfaces/interfaces.ts";

export default function ProjectsPanel() {
    const { state, setState } = useProjects()!;

    function handleAddProject() {
        const newProject = {
            id: state.length + 1,
            name: "New Project",
            description: null,
            tickets: [],
        }
        setState([...state, newProject]);
    }

    function handleProjectClick(project: IProject) {
        const tickets = project.tickets;
    }

    return (
        <>
            <div className="row mt-2">
                <div className="col text-end">
                    <button className="btn btn-primary" onClick={handleAddProject}>+</button>
                </div>
            </div>
            <ul className="list-group mt-2">
                {state.map(project =>
                    <li key={project.id} className="list-group-item"
                        onClick={() => handleProjectClick(project)}
                    >
                        {project.name}</li>)
                }
            </ul>
        </>
    );
}