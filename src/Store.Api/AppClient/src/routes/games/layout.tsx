import { Slot, component$ } from "@builder.io/qwik";
import Header from "~/components/header/header";

export default component$(() => {
    return (
        <>
            <Header />
            <div class="bg-blue-800">
                <p class="text-white text-center">OFERTAS ESPECIALES Y PRODUCTOS A PRECIOS INCREÍBLES.</p>
            </div>
            <Slot />
        </>
    );
});
