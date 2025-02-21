import {useProjects} from "../context/ProjectContext.tsx";
import {IProject} from "../interfaces/interfaces.ts";
import {useEffect, useRef, useState} from "react";
import {Client} from "../http/Client.ts";
import {UniversalModal} from "./UniversalModal.tsx";
import {Form} from 'react-bootstrap';


export default function ProjectsPanel() {
    const {state, setState} = useProjects();
    const [showModal, setShowModal] = useState(false);
    const modalRef = useRef<HTMLInputElement | null>(null);

    useEffect(() => {
        (async () => {
            const client = new Client();
            const respProjects = await client.getProjects();
            if (respProjects) {
                setState([...respProjects.returned!]);
            }
            // const respTags = await client.getTags();
            // if(respTags) {
            //     setTags([...respTags.returned!]);
            // }
        })();
    }, []);

    function handleAddProject() {
        if (modalRef) {
            setShowModal(true);
        }
    }

    const addProject = () => {
        const projectName = modalRef.current?.value.trim();
        if (projectName) {
            setState([...state,
                {
                    id: state.length + 1,
                    name: projectName || '',
                    description: null,
                    tickets: [],
                    tags: []
                }]);
            if (modalRef.current) {
                modalRef.current.value = "";
            }
            setShowModal(false);
        }
    };

    function handleProjectClick(project: IProject) {
        setState([...state, project]);
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
            <UniversalModal
                show={showModal}
                handleClose={() => setShowModal(false)}
                onConfirm={addProject}
                title="Создать новый проект"
                ref={modalRef}
            >
                <Form>
                    <Form.Group>
                        <Form.Label>Название проекта</Form.Label>
                        <Form.Control
                            type="text"
                            ref={modalRef}
                            placeholder="Введите название"
                        />
                    </Form.Group>
                </Form>
            </UniversalModal>
        </>
    );
}