import {useProjects} from "../context/ProjectContext.tsx";
import {ITicket} from "../interfaces/interfaces.ts";

export default function TicketsPanel() {
  const {state} = useProjects() ?? {};
  const tickets = state?.selectedProject?.tickets || [];

  const handleAddTicket = () => {
  }

  return (
    <>
      <div className="row mt-2">
        <div className="col text-end">
          <button className="btn btn-primary" onClick={handleAddTicket}>Add Ticket</button>
        </div>
      </div>
      <div className="row mt-2">
        <div className="col">
          <table className="table">
            <thead>
            <tr>
              <th scope="col">#</th>
              <th scope="col">Title</th>
              <th scope="col">Status</th>
              <th scope="col"></th>
            </tr>
            </thead>
            <tbody>
            {tickets.map((ticket: ITicket) => (
              <tr>
                <th scope="row">{ticket.id}</th>
                <td>{ticket.title}</td>
                <td>{ticket.status.name}</td>
                <td>
                  <button className="btn btn-primary">Details</button>
                </td>
              </tr>
            ))}
            </tbody>
          </table>
        </div>
      </div>
    </>);
}