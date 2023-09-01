import { Slot, component$ } from "@builder.io/qwik";
import Dashboard from "~/components/Dashboard/Dashboard";

export default component$(() => {
    return (
        <div class="min-h-scree ">
            <div class="grid grid-cols-6 gap-4 p-4">
                <Dashboard />
                <Slot />
            </div>
        </div>
    );
});
