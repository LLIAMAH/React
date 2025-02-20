import 'bootstrap/dist/css/bootstrap.css';
import './App.css'
import 'bootstrap/dist/js/bootstrap.bundle.js'
import NavBarMenu from "./components/NavBarMenu.tsx";
import ProjectsPanel from "./components/ProjectsPanel.tsx";

function App() {
    return (
        <>
            <NavBarMenu/>
            <div className="row">
                <div className="col-3">
                    <ProjectsPanel />
                </div>
                <div className="col">

                </div>
            </div>
        </>
    )
}

export default App
