import { component$, useSignal, useTask$ } from "@builder.io/qwik";
import Product from "~/components/product/product";
import { type GameResponse } from "~/modules/Game/Domain/GameResponse";
import { ApiGameRepository } from "~/modules/Game/infrastructure/ApiGameRepository";
import { type BaseResponse } from "~/modules/types/BaseResponse";

export default component$(() => {
    const responseJson = useSignal<BaseResponse<GameResponse[]>>();
    useTask$(async () => {
        responseJson.value = await ApiGameRepository.getAll();
    });

    return (
        <div>
            <div class="flex justify-center">
                <div class="w-[900px] grid grid-cols-2 gap-4 pt-5 m-10">
                    <Product data={responseJson.value?.data} />
                </div>
            </div>
        </div>
    );
});
