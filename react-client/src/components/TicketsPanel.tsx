import {IContextData, useProjects} from "../context/ProjectContext.tsx";
import {IError, IStatus, ITicket} from "../interfaces/interfaces.ts";
import {useRef, useState} from "react";
import {UniversalModal} from "./UniversalModal.tsx";
import {Form} from "react-bootstrap";
import {TicketNewModal} from "./TicketNewModal.tsx";

export default function TicketsPanel() {
  const {state, setState} = useProjects()!;
  const [showModal, setShowModal] = useState(false);
  const [error, setError] = useState<IError | undefined>(undefined);
  const tickets = state?.selectedProject?.tickets || [];
  const modalRef = useRef<HTMLInputElement | null>(null);
  const modalErrorRef = useRef<HTMLDivElement | null>(null);

  const handleAddTicket = () => {
    if (modalRef) {
      setShowModal(true);
    }
  }

  const addTicket = (ticket: { id: number, title: string; description: string, status: IStatus }) => {
    clearTicketsSelections(state);

    if (ticket.title.trim()) {
      const newId = state.selectedProject!.tickets!.length > 0
        ? Math.max(...state.selectedProject!.tickets.map(ticket => ticket.id)) + 1
        : 1;

      const ticketNew = {
        id: newId,
        title: ticket.title,
        description: ticket.description,
        status: ticket.status,
        isSelected: true
      };

      const tickets: ITicket[] = [...state.selectedProject?.tickets || [], ticketNew];
      const selectedProject = state.selectedProject!;
      selectedProject.tickets = tickets;

      setState({
        ...state,
        selectedProject: selectedProject,
        selectedProjectTickets: tickets
      });

      setShowModal(false);
    }
  }

  const clearTicketsSelections = (state: IContextData) => {
    state.selectedProjectTickets.forEach((value: ITicket) => {
      value.isSelected = false;
    });
  }

  return (
    <>
      <div className="row mt-2">
        <div className="col text-end">
          <button className="btn btn-primary" onClick={handleAddTicket} disabled={state.selectedProject === null}>
            Add Ticket
          </button>
        </div>
      </div>
      <div className="row mt-2">
        <div className="col">
          <table className="table">
            <thead>
            <tr>
              <th className="col-1" scope="col">#</th>
              <th className="col" scope="col">Title</th>
              <th className="col-2" scope="col">Status</th>
              <th className="col-1" scope="col"></th>
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
      <UniversalModal show={error != undefined}
                      handleClose={() => setError(undefined)}
                      ref={modalErrorRef}
                      title="Error!"
      >
        <Form.Label>{error?.message}</Form.Label>
      </UniversalModal>
      <TicketNewModal
        ref={modalRef}
        show={showModal}
        handleClose={() => setShowModal(false)}
        onConfirm={addTicket}
        title="Create new ticket"
      />
    </>);
}