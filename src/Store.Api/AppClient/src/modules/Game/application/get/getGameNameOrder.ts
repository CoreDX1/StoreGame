import { type BaseResponse } from "~/modules/types/BaseResponse";
import { type GameResponse } from "../../Domain/GameResponse";

export interface Order {
    order: "asc" | "desc";
}

export async function getGameNameOrder({ order }: Order): Promise<BaseResponse<GameResponse[]>> {
    const game = await fetch("http://localhost:5099/api/Game/order", {
        method: "POST",
        headers: {
            "content-type": "application/json",
        },
        body: JSON.stringify({ order: order }),
    });
    const json = await game.json();
    return json;
}
