import { component$, Slot } from "@builder.io/qwik";
import { routeLoader$ } from "@builder.io/qwik-city";

import Header from "~/components/header/header";

export const useServerTimeLoader = routeLoader$(() => {
    return {
        date: new Date().toISOString(),
    };
});

export default component$(() => {
    return (
        <>
            <Header />
            <div class="bg-blue-800">
                <p class="text-white text-center">OFERTAS ESPECIALES Y PRODUCTOS A PRECIOS INCREÍBLES.</p>
            </div>
            <Slot></Slot>
        </>
    );
});
