<template>
    <div class="breeding child">
        <h1>Breeding</h1>
        <div class="values">
            <div class="height value">
                <div>Height</div>
                <div>{{ height }}</div>
            </div>
            <div class="weight value">
                <div>Weight</div>
                <div>{{ weight }}</div>
            </div>
        </div>
    </div>
</template>

<script>
    export default {
        props: {
            height: {
                type: Number,
                default: 1
            },
            weight: {
                type: Number,
                default: 1
            },
        }
    }
</script>