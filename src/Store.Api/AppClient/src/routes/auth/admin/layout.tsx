import { Slot, component$ } from "@builder.io/qwik";
import Dashboard from "~/components/dashboard/dashboard";

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
